using System;

namespace BookStoreAPI.Utils {
  public class DateTimeUtils {
    public string FORMAT {get; set;} = "HH:mm - dd/MM/yyyy";

    public DateTime Parse(string str) {
      return DateTime.ParseExact(str, FORMAT, null);
    }

    public string ToString(DateTime date){
      return date.ToString(FORMAT);
    }

  }
}