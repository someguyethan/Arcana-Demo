//(c) Samantha Stahlke 2020
//Created for INFR 2310.
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(Animator))]
public class BotController : MonoBehaviour
{
    //public GameObject friend;
    //public GameObject enemy;
    public GameObject goal;

    //How close we should get to our goal before stopping.
    public float goalThreshold = 0.1f;
    //How far we can "see".
    public float sightRange = 10.0f;
    //The angle outwards we can "see".
    public float sightAngle = 45.0f;
    private float cosSightAngle = 0.0f;
    //How close an enemy can get before we punch them.
    public float fightRange = 1.0f;

    private NavMeshAgent agent;
    //private Animator anim;

    private enum AIState
    {
        IDLE = 0,
        HOSTILE,
        PUNCH,
        WAVE,
        WALK
    }

    AIState curState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();

        cosSightAngle = Mathf.Cos(Mathf.Deg2Rad * 0.5f * sightAngle);
    }

    void Update()
    {
        //TODO: Complete this function!

        //Top priority: Deal with enemies.
        /*if (enemy != null && InSight(enemy))
        {
            if (XZDistance(enemy) <= fightRange)
                curState = AIState.PUNCH;
            else
                curState = AIState.HOSTILE;
        }*/
        //Next priority: Deal with the goal.
        /*else*/ if (goal != null && goal.activeInHierarchy
            && XZDistance(goal) > goalThreshold)
        {
            agent.SetDestination(goal.transform.position);
            //curState = AIState.WALK;
        }
        //Next priority: Say hi to friends.
        /*else if (friend != null && InSight(friend))
            curState = AIState.WAVE;
        //What should we do if none of these priorities are relevant?*/
        //else
        //    curState = AIState.IDLE;

        //agent.isStopped = curState != AIState.WALK;

        //anim.SetInteger("StateID", (int)curState);
    }

    //Returns true if the object is in our field of view.
    //(This doesn't do any physics checks.)
    //(You would tap into Unity's physics raycasting if you
    //wanted to do physics/obstacle checks.)
    bool InSight(GameObject obj)
    {
        Vector3 toObj = obj.transform.position - transform.position;
        toObj.y = 0.0f;

        Vector3 forward = transform.forward;
        forward.y = 0.0f;

        return Vector3.Dot(forward.normalized, toObj.normalized) > cosSightAngle
            && toObj.magnitude <= sightRange;
    }

    //Returns the distance to obj in the XZ plane.
    float XZDistance(GameObject obj)
    {
        Vector3 toObj = obj.transform.position - transform.position;
        toObj.y = 0.0f;

        return toObj.magnitude;
    }
}
