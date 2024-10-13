using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FuneralClient.Services {
  public class BuildService : BaseService {

    public BuildService() : base() {
    }

    public Task<List<BuildModel>> GetBuilds() {
      //return GetDataList<BuildModel>("fr.code.list", "[{\"pcd_seq\":\"build\"}]", null);
      var dics = new Dictionary<string, string>() {
        { "pcd_seq", "build"}
      };
      return GetDataList<BuildModel>("fr.code.list", dics, null);

    }

  }
}