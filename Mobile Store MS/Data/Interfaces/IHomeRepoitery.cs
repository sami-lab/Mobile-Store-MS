using Mobile_Store_MS.Data.Repositeries;
using Mobile_Store_MS.ViewModel;
using Mobile_Store_MS.ViewModel.MessagesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IHomeRepoitery
    {
         dashboard Admin();
         List<MessageViewModel> messages(string userID,string personId, string userEmail, string Email);
        Task<List<NotificationsViewModel>> Notifications(string userID, int? skip, int? limit);
        Task<int> Create(MessageViewModel message, string userId);

        Task<bool> UpdateMessagesRead(string Email, string PersonId);
        Task<bool> UpdateNotificationRead(string userID);

        int UserTotalNotification(string userID);

        int countUnreadNotifications(string userID);
        int countUnreadMessages(string userEmail);
        Task<List<UnreadMessages>> countUserUnreadMessages(string UserEmail);
    }
}
