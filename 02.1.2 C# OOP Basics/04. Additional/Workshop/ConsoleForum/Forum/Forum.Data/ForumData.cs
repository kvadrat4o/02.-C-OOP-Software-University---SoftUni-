﻿namespace Forum.Data
{
    using Forum.Models;
    using System.Collections.Generic;

    public class ForumData
    {
        public ForumData()
        {
            this.Users = DataMapper.LoadUsers();
            this.Categories = DataMapper.LoadCategories();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Reply> Replies { get; set; }

        public List<Post> Posts { get; set; }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users);
            DataMapper.SaveReplies(this.Replies);
            DataMapper.SavePosts(this.Posts);
            DataMapper.SaveCategories(this.Categories);
        }
    }
}
