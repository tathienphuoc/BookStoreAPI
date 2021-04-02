using System;

namespace BookStoreAPI.Utils {
  public class DateTimeUtils {
    public static string FORMAT {get; set;} = "HH:mm - dd/MM/yyyy";

    public DateTime Parse(string str) {
      return DateTime.ParseExact(str, FORMAT, null);
    }

    public static string ToString(DateTime date){
      return date.ToString(FORMAT);
    }
  }
}