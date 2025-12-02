using users_service.Src.Models;

namespace users_service.Src.Data
{
    public class UserSeeder
    {
        public static void Seed(UserDataContext context)
        {
            if (!context.UsersData.Any())
            {
                context.UsersData.AddRange(new List<User>
                {
                    new User
                    {
                        Id = Guid.Parse("a08799f8-746f-46b4-8134-2ef211fe705a"),
                        FullName = "Carlos Arauco Colque",
                        Email = "carlos@insightflow.cl",
                        NickName = "Carletto",
                        BirthDate = new DateTime(2000, 10, 10),
                        Address = "Matta 24",
                        PhoneNumber = 823456789,
                        Password = "Carlos123.",
                        Role = "ADMIN",
                        IsDeleted = false
                    },
                    new User
                    {
                        Id = Guid.Parse("9fd8ec52-3aa4-4097-86fa-2c576bc06e01"),
                        FullName = "Jhon Vallecilla",
                        Email = "jhon@insightflow.cl",
                        NickName = "Jhon z",
                        BirthDate = new DateTime(2001, 10, 10),
                        Address = "Ossa 242",
                        PhoneNumber = 823416789,
                        Password = "Jhon123.",
                        Role = "USER",
                        IsDeleted = false        
                    },
                    new User
                    {
                        Id = Guid.Parse("2db519ca-4836-4e01-977f-ec518a081d54"),
                        FullName = "Raul Hidalgo",
                        Email = "raul@insightflow.cl",
                        NickName = "Rauletto",
                        BirthDate = new DateTime(2000, 11, 10),
                        Address = "Bonilla 242",
                        PhoneNumber = 623416789,
                        Password = "Raul123.",
                        Role = "USER",
                        IsDeleted = false        
                    }
                });
            }
        }
    }
}