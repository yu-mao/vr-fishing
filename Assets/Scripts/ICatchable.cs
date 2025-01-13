using UnityEngine;

interface ICatchable

{

    void MoveCatchable();

    //catchables have 

    bool IsItCaught();

    //catchable collides with hook object and gets its position

    bool GivePoints();

    //give points once catchables get boat's position

}
