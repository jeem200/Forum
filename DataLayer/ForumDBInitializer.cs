using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class ForumDBInitializer :DropCreateDatabaseAlways<ForumContext>
    {
       protected override void Seed(ForumContext context)
       {
 	       List<Board> listBoard=new List<Board>();
           listBoard.Add(new Board { BoardId=1, BoardTitle="Computer and Internet"});
           listBoard.Add(new Board { BoardId = 2, BoardTitle = "Science and Math" });
           listBoard.Add(new Board { BoardId = 3, BoardTitle = "History" });
           foreach (Board board in listBoard)
           context.board.Add(board);

           
           List<User> userlist = new List<User>();
           userlist.Add(new User {userID=1,userName="Admin",Mail="admin@ex.com",Password="12345",userType="MasterAdmin" });
           userlist.Add(new User {userID=2,userName="Mod1",Mail="mod1@ex.com",Password="Mod1",userType="Moderator"});
           userlist.Add(new User {userID=3,userName="Mod2",Mail="mod2@ex.com",Password="Mod2",userType="Moderator"});
           userlist.Add(new User {userID=4,userName="User1",Mail="user1@ex.com",Password="User1",userType="User"});
           userlist.Add(new User {userID=5,userName="User2",Mail="user2@ex.com",Password="User2",userType="User"});
           userlist.Add(new User {userID=6,userName="User1",Mail="user3@ex.com",Password="User3",userType="User"});
           foreach (User user in userlist)
               context.user.Add(user);

           List<Thread> threadlist = new List<Thread>();
           threadlist.Add(new Thread { id = 1, title = "lorem ipsum", BoardId = 3, startpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota", status = "Unlocked" });
           threadlist.Add(new Thread { id = 2, title = "lorem ipsum?", BoardId = 3, startpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota ", status = "Unlocked" });
           threadlist.Add(new Thread { id = 3, title = "lorem ipsum?", BoardId = 2, startpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota ", status = "Unlocked" });

           foreach (Thread thread in threadlist)
               context.thread.Add(thread);

           List<Post> postlist = new List<Post>();
           postlist.Add(new Post { postId = 1, postedAt = DateTime.Now, postedBy = 4, postType = "Thread_Reply", ThreadID = 1, description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota " });
           postlist.Add(new Post { postId = 2, postedAt = DateTime.Now, postedBy = 5, postType = "Thread_Reply", ThreadID = 2, description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota " });
           postlist.Add(new Post { postId = 2, postedAt = DateTime.Now, postedBy = 6, postType = "Quote Reply", ThreadID = 2, description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota ",repliedTo=1 });

           foreach (Post p in postlist)
               context.post.Add(p);

           
           base.Seed(context);
       }
    }
}
