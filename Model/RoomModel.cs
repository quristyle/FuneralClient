namespace FuneralClient.Model {
  public class RoomModel : BaseModel {
    public string Preview2 {
      get {

        if (string.IsNullOrEmpty(Preview)) {
          return null;
        }
        else {
          return App.BaseUrl + Preview;

        }

      }
    }

    public bool IsInGoin {
      get {
        return !string.IsNullOrEmpty(Gi_key);
      }
    }

    public string Preview { get; set; }
    public string Rs_nm { get; set; }
    public string Ex_url { get; set; }
    public string Jangji { get; set; }
    public string Next_dt { get; set; }
    public string Last_lever_dttm { get; set; }
    public string Gi_audio { get; set; }
    public string Tbl_cb { get; set; }
    public string Video { get; set; }
    public string Gi_video { get; set; }
    public string Crop_img { get; set; }
    public string Machine_temps { get; set; }
    public string Gi_img { get; set; }
    public string B_nm { get; set; }
    public string B_key { get; set; }
    public string Reservation_cnt { get; set; }
    public string Machine_shutdowns { get; set; }
    public string F_nm { get; set; }
    public string R_nm { get; set; }
    public string Borne_out_dt { get; set; }
    public string Audio { get; set; }
    public string R_key { get; set; }
    public string Layout_corpse_tm { get; set; }
    public string Video_nm { get; set; }
    public string Audio_nm { get; set; }
    public string Sex { get; set; }
    public string G_nm { get; set; }
    public string Chulsang { get; set; }
    public string Machine_names { get; set; }

    List<MachineModel> _machine_list;
    public List<MachineModel> Machine_list { get {
        setMachine();
        return _machine_list; }  }

    void setMachine() {
      if(_machine_list == null) {
        _machine_list = new();
        string[] temps = Machine_temps?.Split(",");
        string[] list = Machine_names?.Split(",");
        string[] mkeys = Machine_authkeys?.Split(",");
        string[] mpowers = Machine_powers?.Split(",");
        for (int i = 0; i < list.Length; i++) {
          MachineModel mm = new() {
            Name = list[i],
            Temp = temps[i],
            Id = mkeys[i],
            IsOn = (mpowers[i] == "on"),
          };
          _machine_list.Add(mm);
        }
      }
    }

    public string Borne_out_tm { get; set; }
    public string Machine_authkeys { get; set; }
    public string Machine_cnt { get; set; }
    public string Gi_key { get; set; }
    public string Machine_powers { get; set; }
    public string Layout_corpse_dt { get; set; }
    public string Paper_grp { get; set; }
    public string Ex_title { get; set; }
    public CodeModel SelectedMovie { get; set; }
    public int SelectedMovieIdx { get; set; }



  }
}
