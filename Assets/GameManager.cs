using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ServerSimulation simulation;

    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;

    public GameObject unitPrefab;

    public UI ui;

    // Start is called before the first frame update
    void Start()
    {

        var playerGO = Instantiate(unitPrefab, playerSpawnPoint);
        var enemyGO = Instantiate(unitPrefab, enemySpawnPoint);

        var playerUnitUI = playerGO.GetComponent<UnitUI>();
        var enemyUnitUI = enemyGO.GetComponent<UnitUI>();

        simulation = new ServerSimulation(OnEnemyEndTurn);

        var playerEntity = simulation.GetPlayerEntity();
        var enemyEntity = simulation.GetEnemyEntity();

        playerUnitUI.SetupOnEntity(playerEntity);
        enemyUnitUI.SetupOnEntity(enemyEntity);

        ui.Setup(UseSkill, playerEntity);
    }

    public void OnEnemyEndTurn()
    {
        ui.UnblockUI();
    }

    public void UseSkill(int skillId)
    {
        var result = simulation.PlayerTurn(skillId);

        if (result)
        {

            if (!simulation.GetEnemyEntity().appendedUnit.IsDied.CurrentValue)
            {
                ui.BlockUI();
                simulation.SimulateEnemyTurn();
            }
        }
    }
    
}
