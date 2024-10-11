
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServerSimulation
{
    private CompositeDisposable _disposable = new();

    private Entity playerEntity;
    private Entity enemyEntity;

    private Action onEnemyEndTurn;

    public ServerSimulation(Action onEnemyEndTurn)
    {
        playerEntity = new Entity(new UnitStatus(50, 50));
        playerEntity.debugName = "Player";
        enemyEntity = new Entity(new UnitStatus(50, 50));
        enemyEntity.debugName = "Enemy";

        playerEntity.SetupSkills(enemyEntity);
        enemyEntity.SetupSkills(playerEntity);

        this.onEnemyEndTurn = onEnemyEndTurn;

        playerEntity.appendedUnit.IsDied.Subscribe(_ => Reset()).AddTo(_disposable);
        enemyEntity.appendedUnit.IsDied.Subscribe(_ => Reset()).AddTo(_disposable);
    }

    public Entity GetPlayerEntity() => playerEntity;
    public Entity GetEnemyEntity() => enemyEntity;

    public void SimulateEnemyTurn()
    {
        List<int> availableSkillId = enemyEntity.skills.Where(c => c.AbleToUse.CurrentValue).Select((c, i) => i).ToList();
        int skillId = availableSkillId[UnityEngine.Random.Range(0, availableSkillId.Count)];

        enemyEntity.TurnPerformed();

        enemyEntity.UseSkill(skillId);


        onEnemyEndTurn?.Invoke();
    }

    public bool PlayerTurn(int skillId)
    {
        playerEntity.TurnPerformed();

        var result = playerEntity.UseSkill(skillId);


        return result;
    }

    public void Reset()
    {
        playerEntity.Reset();
        enemyEntity.Reset();
    }
}

