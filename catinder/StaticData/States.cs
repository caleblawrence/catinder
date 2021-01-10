using System.Collections.Generic;

namespace catinder.StaticData
{
  public class State
  {
    public State(string ab, string name) {
      Name = name;
      Abbreviations = ab;
    }

    public string Name { get; set; }

    public string Abbreviations { get; set; }

  }

  static class StateArray
  {

    public static List<State> States;

    static StateArray()
    {
      States = new List<State>(50);
      States.Add(new State("AL", "Alabama"));
      States.Add(new State("AK", "Alaska"));
      States.Add(new State("AZ", "Arizona"));
      States.Add(new State("AR", "Arkansas"));
      States.Add(new State("CA", "California"));
      States.Add(new State("CO", "Colorado"));
      States.Add(new State("CT", "Connecticut"));
      States.Add(new State("DE", "Delaware"));
      States.Add(new State("DC", "District Of Columbia"));
      States.Add(new State("FL", "Florida"));
      States.Add(new State("GA", "Georgia"));
      States.Add(new State("HI", "Hawaii"));
      States.Add(new State("ID", "Idaho"));
      States.Add(new State("IL", "Illinois"));
      States.Add(new State("IN", "Indiana"));
      States.Add(new State("IA", "Iowa"));
      States.Add(new State("KS", "Kansas"));
      States.Add(new State("KY", "Kentucky"));
      States.Add(new State("LA", "Louisiana"));
      States.Add(new State("ME", "Maine"));
      States.Add(new State("MD", "Maryland"));
      States.Add(new State("MA", "Massachusetts"));
      States.Add(new State("MI", "Michigan"));
      States.Add(new State("MN", "Minnesota"));
      States.Add(new State("MS", "Mississippi"));
      States.Add(new State("MO", "Missouri"));
      States.Add(new State("MT", "Montana"));
      States.Add(new State("NE", "Nebraska"));
      States.Add(new State("NV", "Nevada"));
      States.Add(new State("NH", "New Hampshire"));
      States.Add(new State("NJ", "New Jersey"));
      States.Add(new State("NM", "New Mexico"));
      States.Add(new State("NY", "New York"));
      States.Add(new State("NC", "North Carolina"));
      States.Add(new State("ND", "North Dakota"));
      States.Add(new State("OH", "Ohio"));
      States.Add(new State("OK", "Oklahoma"));
      States.Add(new State("OR", "Oregon"));
      States.Add(new State("PA", "Pennsylvania"));
      States.Add(new State("RI", "Rhode Island"));
      States.Add(new State("SC", "South Carolina"));
      States.Add(new State("SD", "South Dakota"));
      States.Add(new State("TN", "Tennessee"));
      States.Add(new State("TX", "Texas"));
      States.Add(new State("UT", "Utah"));
      States.Add(new State("VT", "Vermont"));
      States.Add(new State("VA", "Virginia"));
      States.Add(new State("WA", "Washington"));
      States.Add(new State("WV", "West Virginia"));
      States.Add(new State("WI", "Wisconsin"));
      States.Add(new State("WY", "Wyoming"));
    }
  }
}