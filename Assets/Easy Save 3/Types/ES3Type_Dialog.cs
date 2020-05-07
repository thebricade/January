using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("mood", "chatLog")]
	public class ES3Type_Dialog : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_Dialog() : base(typeof(DialogManager.Dialog)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (DialogManager.Dialog)obj;
			
			writer.WriteProperty("mood", instance.mood);
			writer.WriteProperty("chatLog", instance.chatLog);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (DialogManager.Dialog)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "mood":
						instance.mood = reader.Read<DialogManager.Dialog.GameMood>();
						break;
					case "chatLog":
						instance.chatLog = reader.Read<DialogManager.Dialog.MessageNumber>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new DialogManager.Dialog();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_DialogArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DialogArray() : base(typeof(DialogManager.Dialog[]), ES3Type_Dialog.Instance)
		{
			Instance = this;
		}
	}
}