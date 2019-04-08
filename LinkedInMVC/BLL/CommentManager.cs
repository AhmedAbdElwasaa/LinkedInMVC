using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class CommentsManager : Repository<Comment, ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public CommentsManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public Post AddComment(Comment userComment)
        {
            //Add Comment with user id in Comments table
            
            context.Comments.Add(userComment);

            context.SaveChanges();

            //Update number of Comments in post table
            Post post = context.Posts.FirstOrDefault(p => p.Id == userComment.Fk_PostId);
            post.numOfComments = post.numOfComments + 1;
            PostsManager postsManager = new PostsManager(context);
            postsManager.Update(post);
            return context.Posts.FirstOrDefault(p => p.Id == userComment.Fk_PostId);
        }

        public List<Comment> GetCommentByPostId(int postId)
        {
            return context.Comments.Where(c => c.Fk_PostId == postId).ToList();
        }

        public List<Comment> GetCommentByPostIdAjax(int postId, int i)
        {
            var ajaxCmnts = new List<Comment>();
            var allComments = GetCommentByPostId(postId);

            for (; i < allComments.Count(); ++i)
            {
                ajaxCmnts.Add(allComments[i]);
            }
            return ajaxCmnts;
        }
    }
}