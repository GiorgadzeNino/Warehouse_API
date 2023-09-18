using BTUProject.DataAccess;
using BTUProject.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTUProject.DataAccess
{
    public class WarehouseDbInitializer
    {
        public static void Initialize(WarehouseDbContext context)
        {
            var initializer = new WarehouseDbInitializer();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Gender ON");
            context.Database.Migrate();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(WarehouseDbContext context)
        {
            context.Database.EnsureCreated();

            SeedGenders(context);
            SeedRelationTypes(context);
            SeedCountries(context);
            SeedCities(context);
        }


        private void SeedGenders(WarehouseDbContext context)
        {
            // Check if the Genders are already seeded
            if (context.Gender.Any())
            {
                return;
            }

            // Seed Genders
            var genders = new List<GenderTypesEnum>
            {
                GenderTypesEnum.Female,
                GenderTypesEnum.Male
            };

            foreach (var gender in genders)
            {
                context.Gender.Add(new Gender // Replace with your entity type
                {
                    //Id = (int)gender,
                    Name = gender.ToString()
                });
            }

            context.SaveChanges();
        }

        private void SeedRelationTypes(WarehouseDbContext context)
        {
            // Check if the Genders are already seeded
            if (!context.RelationshipTypes.Any())
            {

                // Seed Genders
                var relationTypes = new List<RelationshipTypesEnum>
            {
                RelationshipTypesEnum.Mother,
                RelationshipTypesEnum.Father,
                RelationshipTypesEnum.Spouse,
                RelationshipTypesEnum.Familiar,
                RelationshipTypesEnum.Relative,
                RelationshipTypesEnum.Other
            };

                foreach (var relation in relationTypes)
                {
                    context.RelationshipTypes.Add(new RelationshipTypes
                    {
                        Name = relation.ToString()
                    });
                }

                context.SaveChanges();
            }
        }

        private void SeedCountries(WarehouseDbContext context)
        {
            // Check if the Genders are already seeded
            if (!context.Countries.Any())
            {

                context.Countries.Add(new Countries
                {
                    Name = "Georgia"
                });
                context.Countries.Add(new Countries
                {
                    Name = "USA"
                });
                context.Countries.Add(new Countries
                {
                    Name = "Ukraine"
                });


                context.SaveChanges();
            }
        }
      
        private void SeedCities(WarehouseDbContext context)
        {
            // Check if the Genders are already seeded
            if (!context.Cities.Any())
            {

                context.Cities.Add(new Cities
                {
                    Name = "Tbilisi"
                });
                context.Cities.Add(new Cities
                {
                    Name = "New York"
                });
                context.Cities.Add(new Cities
                {
                    Name = "Kyiv"
                });


                context.SaveChanges();
            }
        }
    }

}