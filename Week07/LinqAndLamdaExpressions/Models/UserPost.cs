using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLamdaExpressions.Models
{
    
        public class UserPost
        {
            public User User { get; set; }
            public List<Post> Posts { get; set; }
            public UserPost()
            {
                this.User = User;
                this.Posts = new List<Post>();
            }

        }
    
}
