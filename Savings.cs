using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ØkonomiSystemet
{
    public class Savings
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private int ProjectCount { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SavingsId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }




        public Savings(string title, string description)
        {
            Title = title;
            Description = description;
            ProjectCount = 0;
         
  
        }

        public Savings()
        {
  
        }




        public void SavingsMenu(User user)
        {

            bool savingschoice = true;
            while (savingschoice)
            {

                Console.WriteLine();
                Console.WriteLine("[Saving]");
                Console.WriteLine("1.Project List");
                Console.WriteLine("2.Create Project");
                Console.WriteLine("3.Profile");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    AllProjects(user);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    MakeProject(user);

                }
                else if (input == "3")
                {
                    savingschoice = false;
                    Console.Clear();
               
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
        }





        public void ProjectList(User user )
        {
            Console.WriteLine("choose project you would like to watch/edit");
            NoProjects(user);
            int projectNr = 0;
            foreach (var project in user.UserSavingProjects)
            {
                projectNr++;
                Console.WriteLine($"{projectNr}-ProjectName: {project.Title} ");

            }


           
       

            int UserProjectNr = Convert.ToInt32(Console.ReadLine());
            if (UserProjectNr > 0 && UserProjectNr <= user.UserSavingProjects.Count)
            {
                ProjectUserSetting(UserProjectNr, user);
            }
        }

        void ProjectUserSetting(int UserProjectNr, User user)
        {
            Console.Clear();
            var choosenProject = user.UserSavingProjects[UserProjectNr - 1];
            Console.WriteLine($"Title: {choosenProject.Title}");
            Console.WriteLine($"Description:{choosenProject.Description}");
            projectCommando(choosenProject, user);
        }

        void EditProject()
        {

        }


        void projectCommando(Savings choosenProject,User user )
        {
            Console.WriteLine("1.Edit");
            Console.WriteLine("2.delete");
            Console.WriteLine("3.exit");
            var Userinput = Console.ReadLine();
            if (Userinput == "1")
            {
                EditProject();
            }
            else if (Userinput == "2")
            {
                var dbCon = new DbConnection();
                user.UserSavingProjects.Remove(choosenProject);
                dbCon.removeSavings(choosenProject);
                dbCon.SaveChanges();
                Console.WriteLine($"Project  {choosenProject.Title} has been deleted");


            }
            else if (Userinput == "3")
            {
                Console.Clear();
            }
        }

        void NoProjects(User user)
        {
            if (user.UserSavingProjects.Count == 0)
            {
                Console.WriteLine("No existing project...");
          
            }
        }




        void AllProjects(User user)
        {
            if (user.UserSavingProjects.Count != 0)
            {
                ProjectList(user);
            }
            else
            {
                Console.WriteLine("You don't have any Projects!");
            }
        }


        public string title()
        {
            Console.WriteLine("Enter project name: ");
            string projectName = Console.ReadLine();
       
            return projectName;
        }

        public string description()
        {
            Console.WriteLine("Enter Description");
            string ProjectDescription = Console.ReadLine();
            return ProjectDescription;
        }

        public void MakeProject(User user)
        {
            var dbCon = new DbConnection();
            Console.WriteLine($"you have {user.UserSavingProjects.Count} projects, add a new project");
            string ProjectTitle = title();
            string ProjectDescription = description();
            Savings newuserproject = new Savings(ProjectTitle, ProjectDescription);
            user.UserSavingProjects.Add(newuserproject);

            Console.WriteLine($"project: [{ProjectTitle}] has been added");
            Console.WriteLine();

            dbCon.WriteSavings(ProjectTitle, ProjectDescription, user);
            dbCon.SaveChanges();
        }
    }
}