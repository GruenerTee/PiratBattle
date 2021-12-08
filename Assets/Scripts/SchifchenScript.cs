using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SchifchenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PiratBattle _inputSystem;
    private Vector2 _Movement;
    Rigidbody _Body;
    public GameObject _Bullet;
    public Camera _Camera;
    [SerializeField] 
    float _speed = 1f;
    public GameObject _PausMenu;
    private float _timeSinceLastShot;
    private int _Healt;
    public  HealtBarScript healtBarScript;
    public ScoreScript scoreScript;
    private int _score;

    public bool GameisPaused { get; private set; }

    void Awake()
    {
        _Body = GetComponent<Rigidbody>();
        _timeSinceLastShot = Time.time;

        _inputSystem = new PiratBattle();
        //_inputSystem.Player.Move.performed += ctx => Move(ctx);
        _inputSystem.Player.Move.Enable();
        GameisPaused = false;
        _Healt = 100;
        healtBarScript.SetMaxHealth(_Healt);
        healtBarScript.SetHealtBar(_Healt);
        _score = 0;
        scoreScript.SetScoreText( _score.ToString());

        


        //_inputSystem.See.Move.canceled += ctx => Move(new Vector2(0, 0));
    }
    private void OnEnable()
    {
        _inputSystem.Player.Move.Enable();
    }
    private void OnDisable()
    {
        _inputSystem.Player.Move.Disable();

    }
    private void FixedUpdate()

    {

        // Debug.Log(_Movement);
        // We add +1 to the x axis every frame.
        // Time.deltaTime is the time it took to complete the last frame
        // The result of this is that the object moves one unit on the x axis every second
        //transform.position += new Vector3(1 * Time.deltaTime, 0, 0);

        _Body.AddForce(((transform.forward) * _speed * _Movement.y));

        if (_Movement.x*_Movement.x > 0.2f)
        {
            _Body.AddForce(transform.right * _Movement.y * _Body.velocity.magnitude);
        }
        
        


        _Body.AddTorque(new Vector3(0, _Movement.x, 0) * _speed);
        if (_Healt <= 0)
        {
            this.transform.SetPositionAndRotation(new Vector3(0, 0, 0), transform.rotation);
            _Healt = 100;
            healtBarScript.SetHealtBar(_Healt);
            _score -= 1;
            scoreScript.SetScoreText(_score.ToString());
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "PlayerParrent(Clone)")
        {
            _Healt -= 10;
            healtBarScript.SetHealtBar(_Healt);
            Debug.Log("Schiffcolision");
        }
        if (collision.gameObject.name == "arrow(Clone)")
        {
            _Healt -= 5;
            healtBarScript.SetHealtBar(_Healt);
            Debug.Log("Pfeiltreffer");
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log( context.ReadValue<Vector2>() );
        _Movement = context.ReadValue<Vector2>();
         
       
    }
    public void PauseMenue(InputAction.CallbackContext context)
    {
        if (GameisPaused == false)
        {


            _PausMenu.SetActive(true);
            Time.timeScale = 0F;
            GameisPaused = true;
        }
        else
        {
            _PausMenu.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
        }



    }
    public void PauseMenuReturn(InputAction.CallbackContext context)
    {
        if (GameisPaused == true)
        {

        
        }

    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (Time.time - _timeSinceLastShot > 0.01)
        {

            GameObject Bulleet = Instantiate(_Bullet, transform.position + transform.up *2  + transform.forward * 20, transform.rotation) as GameObject;
            Bulleet.SetActive(true);
            Bulleet.GetComponent<Rigidbody>().AddForce(Bulleet.transform.forward * 300);
            _timeSinceLastShot = Time.time;
        }
    }
}


