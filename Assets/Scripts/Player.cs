using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float           moveSpeed = 5;
    [SerializeField]
    private float           jumpForce = 15;

    private Rigidbody2D     rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(moveSpeed, jumpForce);

        // StartCoroutine(nameof(UpdateInput)); == StartCoroutine("UpdateInput"); 오타로 에러가 날 가능성을 없앤다.
        StartCoroutine(nameof(UpdateInput));
    }

    private IEnumerator UpdateInput()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                JumpTo();
            }

            yield return null;
        }
    }

    private void JumpTo()
    {
        // velocity는 해당 vector 방향으로 속도를 더한다. 비정삭적 물리 처리이기 때문에 점프같은 상황에 사용 됨
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }

    private void ReverseXDir()
    {
        // -(괄호안에 숫자가 양수면 1, 음수면 -1 반환)
        float x = -Mathf.Sign(rb2D.velocity.x);
        rb2D.velocity = new Vector2(x * moveSpeed, rb2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag.Equals("Wall"))
        {
            //벽에 닿으면 플레이어의 방향을 반대로 바꾼다.
            ReverseXDir();
        }
        
    }
}
