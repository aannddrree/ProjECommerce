using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProjECommerce.Models;
using ProjECommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjECommerce.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionsRepository _connections = new ConnectionsRepository();

        private readonly SignInManager<IdentityUser> _signInManager;

        public ChatHub(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager; 
        }

        /// <summary>
        /// Override para inserir cada usuário no nosso repositório, lembrando que esse repositório está em memória
        /// </summary>
        /// <returns> Retorna lista de usuário no chat e usuário que acabou de logar </returns>
        public override Task OnConnectedAsync()
        {
            var user = JsonConvert.DeserializeObject<User>(Context.GetHttpContext().Request.Query["user"]);
            _connections.Add(Context.ConnectionId, user);
            //Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
            Clients.All.SendAsync("chat", _connections.GetAllUser(), user);
            return base.OnConnectedAsync();
        }


        /// <summary>
        /// Método responsável por encaminhar as mensagens pelo hub
        /// </summary>
        /// <param name="ChatMessage">Este parâmetro é nosso objeto representando a mensagem e os usuários envolvidos</param>
        /// <returns></returns>
        public async Task SendMessage(ChatMessage chat)
        {
            //Ao usar o método Client(_connections.GetUserId(chat.destination)) eu estou enviando a mensagem apenas para o usuário destino, não realizando broadcast
            await Clients.Client(_connections.GetUserId(chat.destination)).SendAsync("Receive", chat.sender, chat.message);
        }
    }
}
