namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");
            

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in users1)
            {
                Console.WriteLine(value.Name);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;
          
            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId );
            }

            // 3 - print number of posts for each user.

            var sum = from post in allPosts
                      group post by post.UserId into UserIdGroup
                      select new
                      {
                          UserId = UserIdGroup.Key,
                          Count = UserIdGroup.Count()
                        
                      };
            foreach (var post in sum)
            {
                Console.WriteLine(post.UserId + " - " + post.Count);
            }

            // 4 - find all users that have lat and long negative.

            var userLatAndLong = from user in allUsers
                                 where (user.Address.Geo.Lat < 0) && (user.Address.Geo.Lng < 0)
                                 select user;
            foreach (var user in userLatAndLong)
            {
                Console.WriteLine(user.Name + " -> " + user.Address.Geo.Lat + " and " + user.Address.Geo.Lng);
            }

            // 5 - find the post with longest body.

            var maxLength = allPosts.Select(post => post.Body.Length).Max();
            var max = from post in allPosts
                      where post.Body.Length == maxLength
                      select post;

            foreach (var post in  max)
            {
                Console.WriteLine(post.Id+" - "+post.Body+" - "+ maxLength);
            }

            // 6 - print the name of the employee that have post with longest body.

            var innerJoin = allUsers.Join(
                      allPosts,  
                      user => user.Id,    
                      post => post.UserId,
                      (user, post) => new  
                      {
                          Body=post.Body,
                          Name = user.Name
                      });
            foreach (var obj in innerJoin)
            {
                if (maxLength == obj.Body.Length)
                {
                    Console.WriteLine(obj.Name);
                }
            }

            // 7 - select all addresses in a new List<Address>. print the list.
            var addresses = from item in allUsers
                            select item.Address;
            List<Address> addresses1 = new List<Address>();
            foreach (var item in addresses)
            {
                addresses1.Add(item);
               
            }
            foreach (var item in addresses1)
            {
                Console.WriteLine(item.Street+", "+ item.Suite + ", " + item.City + ", " + item.Zipcode + ", " + item.Geo.Lat + ", " + item.Geo.Lat);
            }

            // 8 - print the user with min lat
            var minLat = (from user in allUsers
                          select user.Address.Geo.Lat).Min();
            var min = from user in allUsers
                      where user.Address.Geo.Lat == minLat
                      select user;
            foreach (var user in min)
            {
                Console.WriteLine(user.Name + " - " + minLat);
            }

            // 9 - print the user with max long
            var maxLong=(from user in allUsers
                         select user.Address.Geo.Lng).Max();
            var maxL = from user in allUsers
                       where user.Address.Geo.Lng == maxLong
                       select user;
            foreach (var user in maxL)
            {
                Console.WriteLine(user.Name + " - " + maxLong);
            }


            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only


            var postUsers = allPosts.GroupBy(post => post.UserId, post => post);
            UserPost userPosts = new UserPost();
           
            List<UserPost> userPosts1 = new List<UserPost>() ;
            //neterminat


            // 11 - order users by zip code
            var ZipCode = allUsers.OrderBy(user => user.Address.Zipcode); 
            foreach (var user in ZipCode)
            {
                Console.WriteLine($"{user.Address.Zipcode} - {user.Name}");
            }

            // 12 - order users by number of posts
            var OrderUsers = sum.OrderBy(user => user.Count);

            foreach (var user in OrderUsers)
            {
                Console.WriteLine($"{user.UserId} - {user.Count}");
            }

            Console.ReadLine();
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
