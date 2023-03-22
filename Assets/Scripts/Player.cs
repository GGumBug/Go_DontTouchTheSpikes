using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float           jumpForce = 15;

    private Rigidbody2D     rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();

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
}
