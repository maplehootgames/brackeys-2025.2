using UnityEngine;

public class OnClickReview : MonoBehaviour
{
    GameObject star5;
    GameObject star4;
    GameObject star3;
    GameObject star2;
    GameObject star1;

    void start() {
        GameObject star5 = GameObject.Find("5 Full");
        GameObject star4 = GameObject.Find("4 Full");
        GameObject star3 = GameObject.Find("3 Full");
        GameObject star2 = GameObject.Find("2 Full");
        GameObject star1 = GameObject.Find("1 Full");
    }

    public GameObject objecta;
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            objecta.SetActive(true);
            starBoy();
        }
    }
    void starBoy() {
        ReviewSystem reviewer = GameObject.Find("CustomerSpawner").GetComponent<ReviewSystem>();
        int averageReview = reviewer.averageReview();
        if (averageReview == 5) {
            star5.SetActive(true);
            star4.SetActive(true);
            star3.SetActive(true);
            star2.SetActive(true);
            star1.SetActive(true);
        } else if (averageReview == 4) {
            star5.SetActive(false);
            star4.SetActive(true);
            star3.SetActive(true);
            star2.SetActive(true);
            star1.SetActive(true);
        } else if (averageReview == 3) {
            star5.SetActive(false);
            star4.SetActive(false);
            star3.SetActive(true);
            star2.SetActive(true);
            star1.SetActive(true);
        } else if (averageReview == 2) {
            star5.SetActive(false);
            star4.SetActive(false);
            star3.SetActive(false);
            star2.SetActive(true);
            star1.SetActive(true);
        } else if (averageReview == 1) {
            star5.SetActive(false);
            star4.SetActive(false);
            star3.SetActive(false);
            star2.SetActive(false);
            star1.SetActive(true);            
        } else {
            star5.SetActive(false);
            star4.SetActive(false);
            star3.SetActive(false);
            star2.SetActive(false);
            star1.SetActive(false);
        }
    }
}
