using System;
using System.Collections.Generic;
using System.Text;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Service.Services {
    public class GraduateService : BaseService<Graduate>, IGraduateService {
        private readonly IGraduateRepository _graduateRepository;

        public GraduateService(
            IGraduateRepository graduateRepository,
             NotificationHandler notifications) : base(graduateRepository, notifications) {
            _graduateRepository = graduateRepository;
        }

        //pesistencia expecifica aqui
    }
}
