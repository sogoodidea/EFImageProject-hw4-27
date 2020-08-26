using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hw4_27EFImageProject.Data
{
    public class ImagesRepository
    {
        private readonly string _connectionString;

        public ImagesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Image> GetImages()
        {
            using (var context = new ImageContext(_connectionString))
            {
                return context.Images.FromSqlRaw("SELECT * FROM Images ORDER BY DateUploaded DESC").ToList();
            }
        }
        public Image GetImageById(int imageId)
        {
            using (var context = new ImageContext(_connectionString))
            {
                return context.Images.FirstOrDefault(i => i.Id == imageId);
            }
        }
        public void AddImage(Image image)
        {
            using (var context = new ImageContext(_connectionString))
            {
                context.Images.Add(image);
                context.SaveChanges();
            }
        }
        public void AddLike(int imageId)
        {
            using (var context = new ImageContext(_connectionString))
            {
                Image image = context.Images.FirstOrDefault(i => i.Id == imageId);
                image.Likes++;
                context.SaveChanges();
            }
        }
        public int GetLikesById(int imageId)
        {
            using (var context = new ImageContext(_connectionString))
            {
                return context.Images.FirstOrDefault(i => i.Id == imageId).Likes;
            }
        }
    }
}
