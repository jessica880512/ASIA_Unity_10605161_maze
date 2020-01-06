using UnityEngine; //引用

public class mousecontrol : MonoBehaviour
{
    [Range(1, 2000)]
    public int speed = 150;
    [Range(1.5f, 100f)]
    public float turn = 20.5f;
    public bool mission;

    public Transform tran;
    public Rigidbody rig;
    public Animator ani;

    public Rigidbody rigybody;
    void Start()
    {
    }
 
    private void Update()

    {
        Turn();
        Run();
        Catch();
        Attack();
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.name=="crown"&& ani.GetCurrentAnimatorStateInfo(0).IsName("Attack02")) 
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());

            other.GetComponent<HingeJoint>().connectedBody = rigybody;
        }
        if (other.name == "flagA" && ani.GetCurrentAnimatorStateInfo(0).IsName("Attack02")) 
        {
            GameObject.Find("crown").GetComponent<HingeJoint>().connectedBody = null;
        }
    }

    public void Run()
    {

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack02")) return;

        float v = Input.GetAxis("Vertical");

        rig.AddForce(tran.forward * speed * v * Time.deltaTime);

        ani.SetBool("walk", v != 0);
    }
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");    // A 左 -1、D 右 1、沒按 0
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }
    private void Catch()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("pick");
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("attack");
        }
    }
}