using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;


namespace ShopZone.Manager
{
    public class FeedbackManager
    {
        public static Model.Feedback Get(int id, bool? isActive = null, bool? isDeleted = null)
        {
            Model.Feedback feedback = new Model.Feedback();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var feedbacks = entity.Feedbacks.Where(i => i.Id == id).AsQueryable();
                if (isActive != null)
                {
                    feedbacks = feedbacks.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    feedbacks = feedbacks.Where(i => i.IsDeleted == isDeleted);
                }
                feedback = feedbacks.Select(cat => cat).FirstOrDefault();
            }


            return feedback;

        }

        public static List<Model.Feedback> Get(bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.Feedback> feedback = new List<Model.Feedback>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var feedbackList = entity.Feedbacks.AsQueryable();
                if (isActive != null)
                {
                    feedbackList = feedbackList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    feedbackList = feedbackList.Where(i => i.IsDeleted == isDeleted);
                }
                feedback = feedbackList.Select(cat => cat).ToList();
            }

            return feedback;

        }





        public static Model.Feedback Save(Model.Feedback feedback)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (feedback.Id <= 0)
                {

                    var newfeedback = new Entity.Feedback
                    {
                        Name = feedback.Name,
                        Subject = feedback.Subject,
                        Message = feedback.Message,
                        CreatedBy = feedback.CreatedBy,
                        CreatedOn = DateTime.Now,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToFeedbacks(newfeedback);
                    entity.SaveChanges();

                    feedback.Id = newfeedback.Id;
                }
                else
                {
                    var existFeedback = entity.Feedbacks.Where(i => i.IsDeleted == false && i.Id == feedback.Id).FirstOrDefault();
                    if (existFeedback != null)
                    {
                        existFeedback.Name = feedback.Name;
                        existFeedback.Subject = feedback.Subject;
                        existFeedback.IsDeleted = feedback.IsDeleted;
                        existFeedback.IsActive = feedback.IsActive;
                        existFeedback.Message = feedback.Message;
                        entity.SaveChanges();
                    }

                }
            }
            feedback = Get(feedback.Id);
            return feedback;

        }
    }
}