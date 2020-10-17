using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{
    public Vector3 moveDir;
    public float jumpForce;
    public float bulletSpeed;
    private bool isDead; 

    public Vector3 largeScaler = new Vector3(2, 2, 2);
    public float largeDuration = 0.5f;

    public GameObject foot;
    public GameObject gunPoint;

    private float t;
    private bool changeToLarge;
    private bool isScaling;

    private Rigidbody rb;
    private MeshRenderer mr;
    private Animator anim;

    private int a = 1;
    private int[] b = new int[4] { 1, 2, 2, 3 };

    private bool isGrounded;

    private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        anim = GetComponent<Animator>();
        bulletPrefab = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDead)
        //{
        //    return;
        //}

        if (Input.GetKeyDown(KeyCode.K))
        {
            mr.enabled = !mr.enabled;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.01f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.01f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.01f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            isScaling = true;
            changeToLarge = true;
            transform.localScale = Vector3.one * 2;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Collider[] res = Physics.OverlapSphere(transform.position, 3, LayerMask.GetMask("Enemy"));
            for (int i = 0; i < res.Length; i++)
            {
                Destroy(res[i].gameObject);
            }
        }


        if (isScaling)
        {
            if (changeToLarge)
            {
                t += Time.deltaTime;
                if (t > largeDuration)
                {
                    changeToLarge = false;
                }
                t = Mathf.Min(largeDuration, t);
                transform.localScale = Vector3.one + (largeScaler - Vector3.one) * t / largeDuration;
            }
            else
            {
                t -= Time.deltaTime;
                if (t < 0)
                {
                    isScaling = false;
                }
                transform.localScale = Vector3.one + (largeScaler - Vector3.one) * t / largeDuration;
            }
        }

        isGrounded = Physics.Raycast(foot.transform.position, Vector3.down, 0.2f, LayerMask.GetMask("Ground")) ;

        if (Input.GetKeyDown(KeyCode.I))
        {
            //实例化
            GameObject goClone = Instantiate(bulletPrefab, gunPoint.transform.position, Quaternion.identity);
            goClone.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 0) * bulletSpeed;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //SceneManager.LoadScene("Game");
            SceneManager.LoadSceneAsync("Game").completed += delegate { print(1111); };

            //UIManager
            //AudioManager
            //PoolManager  //物件池
            //ResourceManager  //资源加载管理
            //FSM  有限状态机
            //行为树
            //卡牌游戏
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController enemy = collision.transform.GetComponent<EnemyController>();
        if(enemy != null)
        {
            print("you dead!");
            isDead = true;
        }

    }
}
