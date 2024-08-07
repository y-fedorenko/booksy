using Booksy.DAL;
using Booksy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.BLL
{
    public class CommentService
    {
        private readonly CommentDAL _dal;

        public CommentService(CommentDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _dal.GetCommentsAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _dal.GetCommentAsync(id);
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _dal.AddCommentAsync(comment);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _dal.UpdateCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _dal.DeleteCommentAsync(id);
        }
    }
}
