using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class PlanetSortEditor : Editor {

    public override void OnInspectorGUI() {
        PlanetBase myPlanet = (PlanetBase)target;
        //Basic Planet Info
        EditorGUILayout.LabelField("Basic Info:");
        EditorGUILayout.BeginVertical("Box");
        myPlanet.planetSize = EditorGUILayout.IntSlider(new GUIContent("Planet Size(radius in miles): ", "Earth's radius is 3959 miles"), myPlanet.planetSize, 1000, 10000);
        myPlanet.orbitTime = EditorGUILayout.Slider("Orbit Time(in days): ", myPlanet.orbitTime, 200, 1000);
        myPlanet.revolutionTime = EditorGUILayout.Slider("Revolution Time(in hours): ", myPlanet.revolutionTime, 5, 75);
        myPlanet.moonAmount = EditorGUILayout.IntSlider("Number of Moons: ", myPlanet.moonAmount, 0, 500);
        myPlanet.mainColor = EditorGUILayout.ColorField("Main Color: ", myPlanet.mainColor);
        EditorGUILayout.EndVertical();
        //Enviroment Info
        EditorGUILayout.LabelField("Enviromental Info:");
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.MinMaxSlider(new GUIContent("Tempurature(in c): ","Earth's average temp is 14c"),ref myPlanet.lowTemp, ref myPlanet.highTemp, -100, 100);
        EditorGUILayout.LabelField(" ","Min: " + myPlanet.lowTemp + " Max: " + myPlanet.highTemp);
        EditorGUILayout.MinMaxSlider(new GUIContent("Elevation(in miles): ","Above and below sea-level"), ref myPlanet.lowElevation, ref myPlanet.highElevation, -10, 10);
        EditorGUILayout.LabelField(" ", "Min: " + myPlanet.lowElevation + " Max: " + myPlanet.highElevation);
        myPlanet.radiationAmount = EditorGUILayout.Slider(new GUIContent("Amount of Radiation(per orbit): ","Earth's average radiation per year is 3.01"), myPlanet.radiationAmount, 0, 5);
        myPlanet.hasWater = EditorGUILayout.Toggle("Has Water: ",myPlanet.hasWater);


        serializedObject.Update();
        SerializedProperty myElements = serializedObject.FindProperty("mainElements");
        EditorGUILayout.PropertyField(myElements, new GUIContent("Main scientific elements: ","There are 118 elements known on Earth"),true);
        serializedObject.ApplyModifiedProperties();


        EditorGUILayout.EndVertical();
        //Life info
        EditorGUILayout.LabelField("Life form Info:");
        EditorGUILayout.BeginVertical("Box");
        myPlanet.isHabitable = EditorGUILayout.BeginToggleGroup(": Is habitable", myPlanet.isHabitable);
        myPlanet.flora = EditorGUILayout.Toggle(new GUIContent("Has Flora: ","Plants"), myPlanet.flora);
        myPlanet.fauna = EditorGUILayout.Toggle(new GUIContent("Has Fauna: ", "Animals"), myPlanet.fauna);
        EditorGUILayout.EndToggleGroup();
        if(myPlanet.isHabitable == false)
        {
            myPlanet.flora = false;
            myPlanet.fauna = false;
        }
        if (myPlanet.intelligentCreatures = EditorGUILayout.Toggle("Has Intelligent Creatures: ", myPlanet.intelligentCreatures) == true)
        {
            myPlanet.icPopulation = EditorGUILayout.IntField("Intelligent Population: ", Mathf.Max(0, myPlanet.icPopulation));
        }
        else if(myPlanet.intelligentCreatures == false)
        {
            myPlanet.icPopulation = 0;
        }


        EditorGUILayout.EndVertical();

        //Original
        //EditorGUILayout.LabelField("-------------------------------------------------------------------------------------------");
        //base.OnInspectorGUI();
    }
}

