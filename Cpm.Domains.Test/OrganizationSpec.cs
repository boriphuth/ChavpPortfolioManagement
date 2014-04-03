using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using NHibernate.Cfg;

using Cpm.Domains.Entities;
using System.Threading;
using System.Linq;
using NHibernate.Linq;
using Cpm.Domains.Values;
using Cpm.FluentMapping.Mappings;

namespace Cpm.Domains.Test
{
    [TestClass]
    public class OrganizationSpec
    {
        ISessionFactory _sessionFactory = null;
        string _dbFile = "cpm.db";

        [TestInitialize]
        public void Setup()
        {
            _sessionFactory = CreateSessionFactory();

            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // New Chavp Organization
                    var chavpOrg = new Organization
                    {
                        Name = "CHAVP",
                    };

                    session.Save(chavpOrg);

                    // New Marketing, Software Development (SD) department
                    var marketing = new Department
                    {
                        Name = "Marketing",
                    };

                    var softwareDev = new Department
                    {
                        Name = "SD",
                    };

                    // Add Dep to Org
                    chavpOrg.Departments.Add(marketing);
                    chavpOrg.Departments.Add(softwareDev);

                    // Add Person
                    var philipKotler = new Person
                    {
                        FirstName = "Kotler",
                        LastName = "Philip",
                        Department = marketing,
                    };

                    var kentBeck = new Person
                    {
                        FirstName = "Beck",
                        LastName = "Kent",
                        Department = softwareDev,
                    };

                    var mikeBeedle = new Person
                    {
                        FirstName = "Beedle",
                        LastName = "Mike",
                        Department = softwareDev,
                    };

                    var arieVanBennekum = new Person
                    {
                        FirstName = "Bennekum",
                        LastName = "Arie van",
                        Department = softwareDev,
                    };

                    var alistairCockburn = new Person
                    {
                        FirstName = "Cockburn",
                        LastName = "Alistair",
                        Department = softwareDev,
                    };

                    session.Save(philipKotler);
                    session.Save(kentBeck);
                    session.Save(mikeBeedle);
                    session.Save(arieVanBennekum);
                    session.Save(alistairCockburn);

                    // Add Process
                    var scrum = new Process
                    {
                        Name = "Scrum",
                        ShortName = "Scrum"
                    };

                    var productRefinementPhase = new Phase
                    {
                        Name = "Product Refinement",
                        Description = "",
                    };

                    scrum.Phases.Add(productRefinementPhase);
                    scrum.Phases.Add(new Phase
                    {
                        Name = "Sprint Planning",
                    });
                    scrum.Phases.Add(new Phase
                    {
                        Name = "Daily Scrum",
                    });
                    scrum.Phases.Add(new Phase
                    {
                        Name = "Sprint Review",
                    });
                    scrum.Phases.Add(new Phase
                    {
                        Name = "Sprint Retrospective",
                    });

                    var feature = new WorkItemType
                    {
                        Name = "Feature",
                        Description = "New, Change",
                    };
                    var defect = new WorkItemType
                    {
                        Name = "Defect",
                        Description = "Bug, Error",
                    };
                    var retrospective = new WorkItemType
                    {
                        Name = "Retrospective",
                        Description = "Improve Tools, Practices",
                    };
                    scrum.WorkItemTypes.Add(feature);
                    scrum.WorkItemTypes.Add(defect);
                    scrum.WorkItemTypes.Add(retrospective);

                    session.Save(scrum);

                    // Add Projects
                    var cpmPrject = new Project
                    {
                        Code = "CPM",
                        Name = "Cahvp Portfolio Management",
                        Process = scrum,
                    };

                    cpmPrject.Peplo.Add(philipKotler);
                    cpmPrject.Peplo.Add(kentBeck);
                    cpmPrject.Peplo.Add(mikeBeedle);
                    cpmPrject.Peplo.Add(arieVanBennekum);
                    cpmPrject.Peplo.Add(alistairCockburn);

                    var createOrg = new WorkItem
                    {
                        Name = "Create Organization",
                        Description = "As a Root, I want to add new Organization.",
                        Phase = productRefinementPhase,
                        WorkItemType = feature,
                    };
                    createOrg.Estimate(DateTime.Now, 3, Scale.Point);
                    //createOrg.Actual(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));

                    var f1 = new TaskItem
                    {
                        Name = "Coding Organization UI",
                        Description = "",
                    };
                    f1.Estimate(DateTime.Now, 3, Scale.Ticks);

                    var f2 = new TaskItem
                    {
                        Name = "Coding Organization UI",
                        Description = "",
                    };
                    f2.Estimate(DateTime.Now, 1, Scale.Ticks);

                    var f3 = new TaskItem
                    {
                        Name = "Testing create Organization on UI",
                        Description = "",
                    };
                    f3.Estimate(DateTime.Now, 1, Scale.Ticks);

                    createOrg.TaskItems.Add(f1);
                    createOrg.TaskItems.Add(f2);
                    createOrg.TaskItems.Add(f3);

                    cpmPrject.WorkItems.Add(createOrg);
                    cpmPrject.WorkItems.Add(new WorkItem
                    {
                        Name = "Create Department",
                        Description = "As a Root, I want to add new Department.",
                        Phase = productRefinementPhase,
                        WorkItemType = feature,
                    });

                    chavpOrg.Portfolio.Add(cpmPrject);

                    transaction.Commit();
                }
            }

        }

        [TestMethod]
        public void ReadChavpOrg()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = from org in session.Query<Organization>()
                            where org.Name == "CHAVP"
                            select org;

                var chavpOrg = query.FirstOrDefault();

                var deps = chavpOrg.Departments.ToList();

                var cpm = (from p in chavpOrg.Portfolio
                           where p.Code == "CPM"
                          select p).FirstOrDefault();
            }
        }

        //[TestMethod]
        //public void CrudChavpCorp()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        using (var transaction = session.BeginTransaction())
        //        {
        //            var cwnOrg = new Organization
        //            {
        //                Name = "CHAVP",
        //                CreatedBy = "UnitTest",
        //            };

        //            //var cwnOrg = query.FirstOrDefault();
        //            //cwnOrg.ModifiedBy = "Chavp";
        //            session.Save(cwnOrg);
        //            transaction.Commit();
        //        }

        //        using (var transaction = session.BeginTransaction())
        //        {
        //            var query = from org in session.Query<Organization>()
        //                        where org.Name == "CWN"
        //                        select org;

        //            var cwnOrg = query.FirstOrDefault();
        //            Assert.IsNotNull(cwnOrg);

        //            cwnOrg.ModifiedBy = "Dhing";
        //            session.Update(cwnOrg);

        //            session.Delete(cwnOrg);

        //            transaction.Commit();
        //        }
        //    }
        //}

        //[TestMethod]
        //public void AddDepChavpCorp()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        using (var transaction = session.BeginTransaction())
        //        {
        //            var query = from org in session.Query<Organization>()
        //                        where org.Name == "CHAVP"
        //                        select org;

        //            var cwnOrg = query.FirstOrDefault();
        //            //Assert.IsNotNull(cwnOrg);

        //            //var cwnOrg = new Organization
        //            //{
        //            //    Name = "CWN",
        //            //    CreatedBy = "UnitTest",
        //            //};

        //            //var cwnOrg = query.FirstOrDefault();
        //            //cwnOrg.ModifiedBy = "Chavp";

        //            var queryDep = from dep in session.Query<Department>()
        //                           where dep.Name == "BU4"
        //                           select dep;

        //            var bu4 = queryDep.FirstOrDefault();
        //            //session.Save(bu4);

        //            //var bu4 = new Department
        //            //{
        //            //    Name = "BU4",
        //            //};
        //            //session.Save(bu4);

        //            cwnOrg.Departments.Add(bu4);

        //            session.Update(cwnOrg);

        //            transaction.Commit();
        //        }
        //    }
        //}

        //[TestMethod]
        //public void AddPeplo()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        using (var transaction = session.BeginTransaction())
        //        {
        //            //for (int i = 0; i < 100; i++)
        //            //{
        //            //    var person = new Person
        //            //    {
        //            //        FirstName = "555",
        //            //        LastName = i.ToString(),
        //            //    };
        //            //}

        //            var person1 = new Person
        //            {
        //                FirstName = "555",
        //                LastName = "555",
        //            };

        //            var person2 = new Person
        //            {
        //                FirstName = "555",
        //                LastName = "666",
        //            };

        //            session.Save(person1);
        //            session.Save(person2);

        //            transaction.Commit();
        //        }
        //    }
        //}

        //[TestMethod]
        //public void AssignPerson()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        using (var transaction = session.BeginTransaction())
        //        {
        //            var queryP1 = from p in session.Query<Person>()
        //                         where p.FirstName == "555"
        //                         && p.LastName == "555"
        //                         select p;

        //            var queryP2 = from p in session.Query<Person>()
        //                         where p.FirstName == "555"
        //                         && p.LastName == "666"
        //                         select p;

        //            var person1 = queryP1.FirstOrDefault();
        //            var person2 = queryP2.FirstOrDefault();

        //            var queryDep = from dep in session.Query<Department>()
        //                           where dep.Name == "BU4"
        //                           select dep;

        //            var bu = queryDep.FirstOrDefault();

        //            person1.Department = bu;
        //            person2.Department = bu;

        //            session.Update(person1);
        //            session.Update(person2);

        //            transaction.Commit();
        //        }
        //    }
        //}

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                .UsingFile(_dbFile))
                .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<OrganizationMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(_dbFile))
                File.Delete(_dbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
