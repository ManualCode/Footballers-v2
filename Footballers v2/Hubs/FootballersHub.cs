using Footballers_v2.Enums;
using Footballers_v2.Models;
using Microsoft.AspNetCore.SignalR;

namespace Footballers_v2.Hubs
{
    public class FootballersHub: Hub
    {
        public async Task Send(Footballer model)
        {
            model.Country = ((Country)int.Parse(model.Country)).ToString();
            await this.Clients.All.SendAsync("Receive", model);
        }
    }
}
