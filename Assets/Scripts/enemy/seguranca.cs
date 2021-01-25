using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguranca : MonoBehaviour
{
    public float Speed;
    public List<Transform> Points;
    public bool pat = false;
    public bool hut = false;
    public bool hut2 = false;
    public bool hut3 = false;
    public bool hut4 = false;
    public bool hut5 = false;
    public bool hut6 = false;
    public bool hut7 = false;
    public bool danger = false;
    public Transform Target;
    private int _currentTargetIndex;
    private int _currentTargetDirection;
    private Animator CAnimation;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    public GameObject drink;
    public GameObject drink2;
    public GameObject drink3;
    public GameObject radio;
    public GameObject disk;

    public Transform point;
    public float TargetDistance = 5;
    public float cronometro;
    public Transform dho;
    public Transform re;
    public Transform mi;
    public Transform fa;
    public Transform sol;
    public Transform la;
    public Transform si;


    public float tempo;
    // Start is called before the first frame update
    void Start()
    {


        CAnimation = GetComponent<Animator>();
        _currentTargetIndex = 0;
        _currentTargetDirection = +1;
    }

    bool HasReachedTarget()
    {

        return _distanceWantsToMoveThisFrame >= _distanceToTarget;
    }

    void MoveCharacterp(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }
    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= tempo) { notas(); }

        if (hut == true)
        {

            hunt();

        }

        if (hut2 == true)
        {

            hunt2();



        }
        if (hut3 == true)
        {
            hunt3();


        }
        if (hut4 == true)
        {

            hunt4();


        }
        if (hut5 == true)
        {
            hunt5();




        }
        if (hut6 == true)
        {

            hunt6();



        }
        if (hut7 == true)
        {
            hunt7();




        }
        if (danger == true)
        {
            dangerius();




        }
        
    }


    public void tiros()
    {
        switch (Random.Range(0, 8))
        {


            case 1:


                shot(drink);

                break;

            case 2:


                shot(drink2);
                break;

            case 3:


                shot(drink3);

                break;
            case 4:


                shot(radio);

                break;
            case 5:

                shot(disk);

                break;
        }

    }

        void notas()
        {








            switch (Random.Range(0, 8))
            {


                case 1:


                    hut = true;
                    hut2 = false;
                    hut3 = false;
                    hut4 = false;
                    hut5 = false;
                    hut6 = false;
                    hut7 = false;
                    cronometro = 0;

                    break;

                case 2:

                    hut2 = true;

                    hut = false;
                    hut3 = false;
                    hut4 = false;
                    hut5 = false;
                    hut6 = false;
                    hut7 = false;
                    cronometro = 0;

                    break;

                case 3:

                    hut3 = true;
                    hut2 = false;
                    hut = false;
                    hut4 = false;
                    hut5 = false;
                    hut6 = false;
                    hut7 = false;
                    cronometro = 0;


                    break;
                case 4:

                    hut4 = true;
                    hut2 = false;
                    hut3 = false;
                    hut = false;
                    hut5 = false;
                    hut6 = false;
                    hut7 = false;
                    cronometro = 0;


                    break;
                case 5:

                    hut5 = true;

                    hut2 = false;
                    hut3 = false;
                    hut4 = false;
                    hut = false;
                    hut6 = false;
                    hut7 = false;
                    cronometro = 0;

                    break;
                case 6:

                    hut6 = true;

                    hut2 = false;
                    hut3 = false;
                    hut4 = false;
                    hut5 = false;
                    hut = false;
                    hut7 = false;
                    cronometro = 0;

                    break;
                case 7:

                    hut7 = true;
                    hut2 = false;
                    hut3 = false;
                    hut4 = false;
                    hut5 = false;
                    hut6 = false;
                    hut = false;
                    cronometro = 0;


                    break;



            }
        }
        void patrol(Transform currentTarget)
        {

            cronometro = 0;

            Vector3 direction = currentTarget.position - transform.position;
            direction.z = 0;
            direction.y = 0;
            _distanceToTarget = direction.magnitude;


            direction.Normalize();

            _distanceWantsToMoveThisFrame = Speed * Time.deltaTime;


            float actualMovementThisFrame = Mathf.Min(_distanceToTarget, _distanceWantsToMoveThisFrame);

            MoveCharacterp(actualMovementThisFrame * direction);

            if (HasReachedTarget())
            {


                _currentTargetIndex += _currentTargetDirection;
                if (_currentTargetIndex == Points.Count - 1 || _currentTargetIndex == 0)
                {

                    _currentTargetDirection *= -1;

                }
            }


            void OnTriggerEnter2D(Collider2D other)
            {

                if (other.tag == "Escada")
                {
                    CAnimation.SetBool("shot", true);

                }
            }




        }



        void shotoff()
        {

            CAnimation.SetBool("shot", false);

        }

        void hunt()
        {

            Vector3 direction = dho.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();




            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void hunt2()
        {

            Vector3 direction = re.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void hunt3()
        {

            Vector3 direction = mi.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void hunt4()
        {

            Vector3 direction = fa.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void hunt5()
        {

            Vector3 direction = sol.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void hunt6()
        {

            Vector3 direction = la.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {
                cronometro = 0;
                CAnimation.SetBool("shot", true);
            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }


        void hunt7()
        {

            Vector3 direction = si.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {

                CAnimation.SetBool("shot", true);

            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }
        void dangerius()
        {

            Vector3 direction = Target.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float distanceToTarget = direction.magnitude;

            direction.Normalize();

            // Mas se ja estiver perto demais, na verdade quero fugir.
            // Inverte a direção anterior.



            if (distanceToTarget == 0)
            {

                CAnimation.SetBool("shot", true);

            }







            // Faz o movimento terminar exatamente em cima do alvo
            float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

        void MoveCharacter(Vector3 frameMovement)
        {
            transform.position += frameMovement;
        }




        void shot(GameObject tiro)

        {
            GameObject CloneTiro1 = Instantiate(tiro, point.position, point.rotation);


        }
        void shotstop()
        {
            CAnimation.SetBool("shot", false);
            notas();

        }

    
}
