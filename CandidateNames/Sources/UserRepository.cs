using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateNames.Sources
{
    public class UserRepository : IUserRepository
    {
        public string[] GetDeveloperJobApplicants()
        {
            var applicants = new[]
            {
                "Carrie, Kirker",
                "Masako, Freas",
                "Collins, Bill",
                "Smith , Bart",
                "Allen,  Tim",
                "Courtney Tyrrell",
                "Gidget, Borey",
                "Holley, Witte",
                "Robby,  Payeur",
                "Deloise,, Carnegie",
                "Sherwood ,Dille, Tim",
                "Lea, Balfour",
                "Catharine, Capra",
                "Julian, Turman",
                "Hoa ,Wissing",
                "Shanika, Theriault",
                "Eloise ,Fielden",
                "Marylynn, Masterson",
                "Hyun, Gonser",
                "Sherlene , Tumlin",
                "Harley , Delosreyes",
                "Lillie, Stolp",
                "Fred, Noblin",
                "Tangela ,Leider",
                "Long, Bruner",
                "Gaynell, Jaquith",
                "Karey, Whitworth",
                "Arturo, Shanley"
            };

            return applicants;
        }

        public string[] GetTesterJobApplicants()
        {
            var applicants = new[]
            {
                "Viki, Sharer",
                "Jule, Goldblatt",
                "Mao, Aldana",
                "Lorretta, Roman",
                "Scarlet, Solis",
                "Carrie, Kirker",
                "Masako, Freas",
                "Mollie, Rabinowitz",
                "Marceline ,Polley",
                "Earlene, Spake",
                "Eduardo, Benda",
                "Robt, Enderle",
                "Antonio, Mchaney",
                "Tilda, Kahan",
                "Melva, Erby",
                "Latashia, Szewczyk",
                "Faustina, Emberton",
                "Vallie, Bordeau",
                "Janette, Husted",
                "Anglea, Haman",
                "Parker, Doggett",
                "Lael, Chiaramonte",
                "Marie, Spilman",
                "Alene, Dressel",
                "Pamela, Monsour",
                "Bao, Mcardle",
                "Zina, Aikens",
                "Gudrun ,Caughman",
                "Rebecca",
                "Beverlee, Oiler,",
                "Elnora, Meaders,",
                "Becky, Leathers",
                "Lola",
                "Teofila, Gullatt",
                "Jacquiline, Lowrey",
                "Alica, Pellerin",
                "Jodie, Redding",
                "Zoraida, Vallecillo,",
                "Tova, Goranson",
                "Wendolyn, Cicero",
                "Long ,,Pigford",
                "Gaynell, Jaquith",
                "Karey, Whitworth",
                "Arturo, Shanley",
                "Shirl, Clingan",
                "Latarsha, Hollins",
                "Alvera, Keenan",
                "Elisha, Lipps",
                "Sherlyn, Semmes",
                "Galina, Porras"
            };

            return applicants;
        }
    }
}
