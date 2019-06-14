using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Interface
{
    public interface IWorkerServices
    {
        bool CreateWorker(WorkerModel model);
        List<WorkerModel> GetWorkers();
        bool UpdateWork(WorkerModel model);
        WorkerModel GetWorkerById(int id);
        bool DeleteWorker(int id);
    }
}