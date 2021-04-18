using UnityEngine;

namespace Tangiappps
{
    public class CharacterMovement : MonoBehaviour
    {
        public SwipeDirection currentDirection;
        public float xValue;
        public float speedDodge;
        public float jumpDodge;
        public float runSpeed;

        private float newX;
        private CharacterController chController;
        //private Animator animator;

        private void OnEnable()
        {
            SwipeManager.OnSwipe += OnSwipe;
        }

        private void Start()
        {
            chController = GetComponent<CharacterController>();
            //animator = GetComponent<Animator>();
        }

        private void Update()
        {
            chController.SimpleMove(Vector3.zero);
            chController.Move(transform.forward * runSpeed * Time.deltaTime);
            RayCast();
        }

        private void OnSwipe(SwipeDirection direction)
        {
            if(direction==SwipeDirection.Left)
            {
                if(currentDirection==SwipeDirection.Mid)
                {
                    newX = -xValue;
                    currentDirection = SwipeDirection.Left;
                    //animator.Play("LeftSwipe");
                    chController.Move(transform.right * newX);
                }
                else if(currentDirection==SwipeDirection.Right)
                {
                    newX = 0;
                    currentDirection = SwipeDirection.Mid;
                    //animator.Play("LeftSwipe");
                    chController.Move(transform.right * newX);
                }
                if (isTrigerFound)
                    transform.Rotate(new Vector3(0, -90, 0));
            }
            else if (direction == SwipeDirection.Right)
            {
                if (currentDirection == SwipeDirection.Mid)
                {
                    newX = xValue;
                    currentDirection = SwipeDirection.Right;
                    //animator.Play("RightSwipe");
                    chController.Move(transform.right * newX);
                }
                else if (currentDirection == SwipeDirection.Left)
                {
                    newX = 0;
                    currentDirection = SwipeDirection.Mid;
                    //animator.Play("RightSwipe");
                    chController.Move(transform.right * newX);
                }
                if (isTrigerFound)
                    transform.Rotate(new Vector3(0, 90, 0));
            }
            else if(direction==SwipeDirection.Up)
            {
               // newY = jumpDodge;
                //animator.Play("Jump");
            }
            else if (direction == SwipeDirection.Down)
            {
                //animator.Play("Slide");
            }      
        }

        private void RayCast()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
            {
                if (hit.transform.name.Equals("Quad"))
                {
                    print("Object found :" + hit.transform.name);
                    isTrigerFound = true;
                }
                else
                    isTrigerFound = false;
            }
        }

        bool isTrigerFound;

        private void OnDisable()
        {
            SwipeManager.OnSwipe -= OnSwipe;
        }
    }
}