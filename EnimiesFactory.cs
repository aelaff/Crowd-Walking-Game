using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnimiesFactory
{
    public abstract class Enemy : MonoBehaviour
    {
        public GameObject myGO;
        public abstract void Intiate();
        public abstract void ShowParicle();
        public abstract void RunAnimation(int animationIndex);
    }
    public class FallenBomp : Enemy {
        
        public override void Intiate()
        {
            myGO = Instantiate(GameManager.Instance.allEnemies[0],new Vector3(-8f,7f,-15f),Quaternion.identity);
            GameManager.Instance.fallenBompList.Add(myGO);
            myGO.GetComponent<FallenBompEnemyController>().fb = this;
            
        }
        public override void ShowParicle()
        {
            myGO.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(myGO, 2);

            
        }
        public override void RunAnimation(int animationIndex)
        {
            throw new System.NotImplementedException();
        }
    }
    public class RoadObstacle : Enemy
    {
        public override void Intiate()
        {
            GameObject o=Instantiate(GameManager.Instance.allEnemies[1]);
            GameManager.Instance.roadObstacleList.Add(o);

        }
        public override void ShowParicle()
        {
            throw new System.NotImplementedException();
        }
        public override void RunAnimation(int animationIndex)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Human : Enemy
    {
        
        public override void Intiate()
        {
            GameObject o = Instantiate(GameManager.Instance.allEnemies[2],GameManager.Instance.humanPositions[Random.Range(0, GameManager.Instance.humanPositions.Count-1)].position,Quaternion.identity);
            GameManager.Instance.humansList.Add(o);

        }
        public override void ShowParicle()
        {
            throw new System.NotImplementedException();
        }
        public override void RunAnimation(int animationIndex)
        {
            throw new System.NotImplementedException();
        }
    }

    public static class EnemyFactory {
        public static Enemy IntiateEnemy(string enemyName) {
            switch (enemyName) {
                case "FallenBomp":
                    return new FallenBomp();
                    
                case "RoadObstacle":
                    return new RoadObstacle();
                case "Human":
                    return new Human();
                default:
                    return null;
            }
        }
    }


}
