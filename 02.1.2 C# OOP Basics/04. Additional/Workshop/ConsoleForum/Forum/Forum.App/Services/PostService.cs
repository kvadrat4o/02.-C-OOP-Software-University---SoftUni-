namespace Forum.App.Services
{
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;
    using System.Collections.Generic;
    using System.Linq;

    class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            var fd = new ForumData();
            Category category = fd.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            var fd = new ForumData();
            var post = fd.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = fd.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }
            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            var fd = new ForumData();

            var allCategories = fd.Categories.Select(c => c.Name).ToArray();
            return allCategories;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var fd = new ForumData();

            var postIds = fd.Categories.First(c => c.Id == categoryId).PostIds;
            IEnumerable<Post> posts = fd.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            var fd = new ForumData();
            var post = fd.Posts.Find(p => p.Id == postId);

            return new PostViewModel(post);
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData fd)
        {
            var categoryName = postView.Category;
            Category category = fd.Categories.FirstOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                var categories = fd.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                fd.Categories.Add(category);
            }
            return category;
        }

        public static bool TrySavePost(PostViewModel pvm)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(pvm.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(pvm.Title);
            bool emptyContent = !pvm.Content.Any();

            if (emptyCategory || emptyContent || emptyTitle)
            {
                return false;
            }
            var fd = new ForumData();
            Category category = EnsureCategory(pvm, fd);

            int postId = fd.Posts.Any() ? fd.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(pvm.Author, fd);
            int authorId = author.Id;
            string content = string.Join("", pvm.Content);

            Post post = new Post(postId, pvm.Title, content, category.Id, authorId, new List<int>());

            fd.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            fd.SaveChanges();

            pvm.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel rpv, int postId)
        {
            if (!rpv.Content.Any())
            {
                return false;
            }

            var fd = new ForumData();

            var author = UserService.GetUser(rpv.Author, fd);
            var post = fd.Posts.Single(p => p.Id == postId);
            int replyId = fd.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var content = string.Join("", rpv.Content);
            var reply = new Reply(replyId, content, author.Id, postId);

            fd.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            fd.SaveChanges();
            return true;
        }
    }
}
