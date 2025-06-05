using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission.Repositories.Repositories
{
    public class MissionSkillRepository : IMissionSkillRepository
    {
        private readonly MissionDbContext _missionDbContext;

        public MissionSkillRepository(MissionDbContext missionDbContext)
        {
            _missionDbContext = missionDbContext;
        }

        public async Task<bool> AddMissionSkill(MissionSkill missionSkill)
        {
            _missionDbContext.MissionSkills.Add(missionSkill);
            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionSkill(int missionSkillId)
        {
            var missionSkill = await _missionDbContext.MissionSkills.FindAsync(missionSkillId);
            if (missionSkill == null)
                return false;

            _missionDbContext.MissionSkills.Remove(missionSkill);
            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<MissionSkillViewModel>> GetAllMissionSkill()
        {
            return _missionDbContext.MissionSkills
                .Select(s => new MissionSkillViewModel
                {
                    Id = s.Id,
                    SkillName = s.SkillName,
                    Status = s.Status,
                })
                .ToListAsync();
        }

        public Task<MissionSkillViewModel?> GetMissionSkillById(int missionSkillId)
        {
            return _missionDbContext.MissionSkills
                .Where(s => s.Id == missionSkillId)
                .Select(s => new MissionSkillViewModel
                {
                    Id = s.Id,
                    SkillName = s.SkillName,
                    Status = s.Status,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMissionSkill(MissionSkill missionSkill)
        {
            var existingSkill = await _missionDbContext.MissionSkills.FindAsync(missionSkill.Id);
            if (existingSkill == null)
                return false;

            existingSkill.SkillName = missionSkill.SkillName;
            existingSkill.Status = missionSkill.Status;

            await _missionDbContext.SaveChangesAsync();
            return true;
        }
    }
}
