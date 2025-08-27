using UnityEngine;

public class ReviewSystem : MonoBehaviour {
    int oldnum;
    int oldoldnum;

    public int[] reviewList = new int[30];
    public int averageReview() {
        oldnum = 0;
        foreach (int num in reviewList) {
            oldnum = oldoldnum;
            oldnum = oldoldnum + num ;
        }
        return (int)oldnum;
    }
}
