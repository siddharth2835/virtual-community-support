using Mission.Entities.Entities;
using Mission.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionSkillRepository
    {
        Task<List<MissionSkillViewModel>> GetAllMissionSkill();
        Task<MissionSkillViewModel?> GetMissionSkillById(int missionSkillId);
        Task<bool> AddMissionSkill(MissionSkill missionSkill);
        Task<bool> UpdateMissionSkill(MissionSkill missionSkill);
        Task<bool> DeleteMissionSkill(int missionSkillId);
    }
}
