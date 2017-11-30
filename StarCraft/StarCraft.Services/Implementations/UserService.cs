﻿namespace StarCraft.Services.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using StarCraft.Data.Models;
    using StarCraft.Services.Contracts;
    using StarCraft.Web.Data;

    public class UserService : IUserService
    {
        private readonly StarCraftDbContext db;

        public UserService(StarCraftDbContext db)
        {
            this.db = db;
        }

        public async Task BuyBuilding(int buildingId, string userId)
        {
            User user = this.db.Users.FirstOrDefault(a => a.Id == userId);
            Building building = this.db.Buildings.FirstOrDefault(a => a.Id == buildingId);

            if (user.Buildings.FirstOrDefault(a => a.BuildingId == buildingId) != null)
            {
                return;
            }

            if (!(user.Minerals >= building.MineralCost && user.Gas >= building.GasCost))
            {
                return;
            }

            user.Minerals -= building.MineralCost;
            user.Gas -= building.GasCost;
            user.Buildings.Add(new UserBuilding { BuildingId = buildingId, UserId = userId });
            await this.db.SaveChangesAsync();
        }
    }
}