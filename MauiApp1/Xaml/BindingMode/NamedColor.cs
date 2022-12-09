using System.Reflection;
using System.Text;

namespace MauiApp1.Xaml.BindingMode;
public class NamedColor : IEquatable<NamedColor>, IComparable<NamedColor>
{

    #region 이름있는 색상 리스트 - NamedColorList

    /// <summary>
    /// 이름있는 색상 리스트
    /// </summary>
    public static IList<NamedColor> NamedColorList { private set; get; }

    #endregion

    #region 명칭 - Name

    /// <summary>
    /// 명칭
    /// </summary>
    public string Name { private set; get; }

    #endregion
    #region 친숙한 명칭 - FriendlyName

    /// <summary>
    /// 친숙한 명칭
    /// </summary>
    public string FriendlyName { private set; get; }

    #endregion
    #region 색상 - Color

    /// <summary>
    /// 색상
    /// </summary>
    public Color Color { private set; get; }

    #endregion
    #region RGB 디스플레이 - RGBDisplay

    /// <summary>
    /// RGB 디스플레이
    /// </summary>
    public string RGBDisplay { private set; get; }

    #endregion

    #region 생성자 - NamedColor()

    /// <summary>
    /// 생성자
    /// </summary>
    static NamedColor()
    {
        List<NamedColor> namedColorList = new List<NamedColor>();

        StringBuilder stringBuilder = new StringBuilder();

        foreach (FieldInfo fieldInfo in typeof(Colors).GetRuntimeFields())
        {
            if (fieldInfo.IsPublic && fieldInfo.IsStatic && fieldInfo.FieldType == typeof(Color))
            {
                string name = fieldInfo.Name;

                stringBuilder.Clear();

                int index = 0;

                foreach (char character in name)
                {
                    if (index != 0 && Char.IsUpper(character))
                    {
                        stringBuilder.Append(' ');
                    }

                    stringBuilder.Append(character);

                    index++;
                }

                Color color = (Color)fieldInfo.GetValue(null);

                NamedColor namedColor = new NamedColor
                {
                    Name = name,
                    FriendlyName = stringBuilder.ToString(),
                    Color = color,
                    RGBDisplay = string.Format
                    (
                        "{0:X2}-{1:X2}-{2:X2}",
                        (int)(255 * color.Red),
                        (int)(255 * color.Green),
                        (int)(255 * color.Blue)
                    )
                };

                namedColorList.Add(namedColor);
            }
        }

        namedColorList.TrimExcess();

        namedColorList.Sort();

        NamedColorList = namedColorList;
    }

    #endregion

   
    #region 생성자 - NamedColor()

    /// <summary>
    /// 생성자
    /// </summary>
    private NamedColor()
    {
    }

    #endregion

    
    #region 찾기 - Find(name)

    /// <summary>
    /// 찾기
    /// </summary>
    /// <param name="name">명칭</param>
    /// <returns>이름있는 색상</returns>
    public static NamedColor Find(string name)
    {
        return ((List<NamedColor>)NamedColorList).Find(nc => nc.Name == name);
    }

    #endregion
    #region 최근접 색상명 구하기 - GetNearestColorName(color)

    /// <summary>
    /// 최근접 색상명 구하기
    /// </summary>
    /// <param name="color">색상</param>
    /// <returns>최근접 색상명</returns>
    public static string GetNearestColorName(Color color)
    {
        double shortestDistance = 1000;

        NamedColor closestColor = null;

        foreach (NamedColor namedColor in NamedColor.NamedColorList)
        {
            double distance = Math.Sqrt
            (
                Math.Pow(color.Red - namedColor.Color.Red, 2) +
                Math.Pow(color.Green - namedColor.Color.Green, 2) +
                Math.Pow(color.Blue - namedColor.Color.Blue, 2)
            );

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestColor = namedColor;
            }
        }

        return closestColor.Name;
    }

    #endregion

  
    #region 동일 여부 구하기 - Equals(other)

    /// <summary>
    /// 동일 여부 구하기
    /// </summary>
    /// <param name="other">다른 이름있는 색상</param>
    /// <returns>동일 여부</returns>
    public bool Equals(NamedColor other)
    {
        return Name.Equals(other.Name);
    }

    #endregion
    #region 비교하기 - CompareTo(other)

    /// <summary>
    /// 비교하기
    /// </summary>
    /// <param name="other">다른 이름있는 색상</param>
    /// <returns>비교 결과</returns>
    public int CompareTo(NamedColor other)
    {
        return Name.CompareTo(other.Name);
    }

    #endregion
}
