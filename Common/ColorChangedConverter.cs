using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.Common {
  public class ColorChangedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

      Debug.WriteLine($"value : {value}");
      Debug.WriteLine($"targetType : {targetType}");
      Debug.WriteLine($"parameter : {parameter}");

      if ((int)value == 1) {
        return Colors.Red;
      }
      else if ((int)value == 2) {
        return Colors.Blue;
      }
      else {
        return Colors.Green;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }


  public class VisibleChangedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {


      string[] colors = ((string)parameter).Split(",");
      Color use = Color.FromArgb("#"+ colors[0]);
      Color unUse = Color.FromArgb("#" + colors[1]);

      Type tp = value.GetType();
      
      if( tp == typeof(string)) {
        if ( string.IsNullOrEmpty((string)value) 
          || ((string)value) == "0" 
          || ((string)value).ToLower() == "false" ) {
          return unUse;
        }
        else {
          return use;
        }

      }
      else {
        if ((bool)value == true) {
          return use;
        }
        else {
          return unUse;
        }

      }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }




  public class BoolChangedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

      string target_str = (string)parameter;

      if ((string)value == target_str) {
        return true;
      }
      else {
        return false;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }


  public class BoolNotChangedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

      string target_str = (string)parameter;

      if ((string)value != target_str) {
        return true;
      }
      else {
        return false;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }




  public class EmptyStringChangedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      if (string.IsNullOrEmpty( (string)value )) {
        return true;
      }
      else {
        return false;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }




}
