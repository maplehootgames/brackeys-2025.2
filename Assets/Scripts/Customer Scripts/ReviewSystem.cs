using UnityEngine;
using System.Linq;

public class ReviewSystem : MonoBehaviour {
    public int[] reviewList = new int[30];
    public int averageReview() {
        double avg = reviewList.Average();
        return (int)avg;
    }
}
