using DemoInheritance;
Shape sh = new Shape();
sh.Color = "red";
Console.WriteLine($"Shape color: {sh.Color}");
string sColor = sh.Color;
Rectangle rg = new Rectangle();
rg.Color = "blue";
Console.WriteLine($"Rectangle color: {rg.Color}");
rg.Draw();
rg.Show();
//sh.Show();// Error
Shape sr = new Rectangle();
sr.Draw();
sr.Print();
if(sr  is Rectangle)
{
    Rectangle rr = (Rectangle)sr;
    Rectangle rr2 = sr as Rectangle;
    rr2.Draw();
}