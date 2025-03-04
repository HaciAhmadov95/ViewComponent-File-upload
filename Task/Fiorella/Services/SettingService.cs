﻿using Fiorella.Data;
using Fiorella.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);

        }
    }
}
