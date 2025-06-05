using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mission.Services.Services
{
    public class MissionSkillService : IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository;

        public MissionSkillService(IMissionSkillRepository missionSkillRepository)
        {
            _missionSkillRepository = missionSkillRepository;
        }

        public Task<bool> AddMissionSkill(MissionSkillViewModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
            };
            return _missionSkillRepository.AddMissionSkill(missionSkill);
        }

        public Task<bool> DeleteMissionSkill(int missionSkillId)
        {
            return _missionSkillRepository.DeleteMissionSkill(missionSkillId);
        }

        public Task<List<MissionSkillViewModel>> GetAllMissionSkill()
        {
            return _missionSkillRepository.GetAllMissionSkill();
        }

        public Task<MissionSkillViewModel?> GetMissionSkillById(int missionSkillId)
        {
            return _missionSkillRepository.GetMissionSkillById(missionSkillId);
        }

        public Task<bool> UpdateMissionSkill(MissionSkillViewModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
            };
            return _missionSkillRepository.UpdateMissionSkill(missionSkill);
        }
    }
}