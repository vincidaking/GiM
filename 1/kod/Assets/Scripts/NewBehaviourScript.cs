using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    private int _points;

    private const int PointPickUp1 = 1;
    private const int PointPickUp2 = 4;

    private bool _finishedGame;

    private GameObject _endText;
    private Rigidbody _rigidbody;
    void Start()
    {
        _points = 0;
        _endText = GameObject.Find("EndText");
        _endText.SetActive(false);
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_finishedGame)
        {
            _rigidbody.Sleep();
            return;
        }

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f,moveVertical);
        _rigidbody.AddForce(movement * Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PickUp"))
        {
            other.gameObject.SetActive(false);
            _points += PointPickUp1;
        }

        if (other.gameObject.tag.Equals("PickUp2"))
        {
            other.gameObject.SetActive(false);
            _points += PointPickUp2;
        }

        if (_points > 9)
        {
            _finishedGame = true;
            _endText.SetActive(true);
        }

        var pointText = GameObject.Find("PointsText").GetComponent<TextMesh>();
        pointText.text = $"Points: {_points}";
    }
}
