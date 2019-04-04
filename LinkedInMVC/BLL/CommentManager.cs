﻿using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class CommentManager : Repository<Comment, ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public CommentManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
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