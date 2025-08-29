using UnityEngine;

public class OnClickReview : MonoBehaviour
{
    public GameObject star5;
    public GameObject star4;
    public GameObject star3;
    public GameObject star2;
    public GameObject star1;
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
        Debug.Log(averageReview);
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
