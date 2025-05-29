using DG.Tweening;
using Enemy;
using UnityEngine;

namespace Enemy {
    public class Kamikaze : BaseEnemy
    {
        [Space, SerializeField]
        private SpriteRenderer m_explosionSprite;
        [SerializeField]
        private GameObject m_explosionFX;
        [SerializeField]
        private Animator animator;


        protected override void Start()
        {
            base.Start();
            m_transform.DOMove(m_playerTransform.position, 1f).SetEase(Ease.InQuad).SetDelay(3f).OnComplete(Attack);
            float multiply = 1f;
            DOTween.To(() => multiply, x => multiply = x, 3f, 3f).OnUpdate(() =>
            {
                animator.SetFloat("multiply", multiply);
            });
        }

        protected override void Update()
        {
            
        }

        protected override void Attack()
        {
            m_explosionSprite.transform.DOScale(3f, 0.5f);
            m_explosionSprite.DOFade(0.2f, 0.5f).SetLoops(6, LoopType.Yoyo).OnComplete(Explode);
            
        }

        private void Explode()
        {
            GameObject explosion = Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);

            if (Vector3.Distance(m_transform.position, m_playerTransform.position) <= 3f)
            {
                GlobalVariables.instance.PlayerHitTriggered();
            }

            GlobalVariables.instance.EnemyDeffeatedTriggered();

            m_audioManager.PlayAudio(2, 1f, Random.Range(0.8f, 1.1f));

            Destroy(explosion, 2f);
            Destroy(gameObject); 
        }
    }
}
