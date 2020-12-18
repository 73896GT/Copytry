using System;

namespace Copytry
{
    abstract class Storage
    {
        protected string Model_name { get; set; }
        public Storage(string Model_name)
        {
            this.Model_name = Model_name;
        }
        abstract public int Get_memory_size();
        abstract public double Copying_data(double x, double y);
        abstract public int Get_memory_free();
        abstract public void Get_info();
    }

    class DVD : Storage
    {
        private int Speed_read_of_recording { get; set; }
        private string Type { get; set; }
        private int Memory;
        private int notFreeMemory = 0;
        int time;

        public DVD(int Speed_read_of_recording, string Type, string Model_name) : base(Model_name)
        {
            this.Speed_read_of_recording = Speed_read_of_recording;
            this.Type = Type;
            this.Model_name = Model_name;

        }

        public override double Copying_data(double amount_files, double memory_file)
        {
            time = Convert.ToInt32((amount_files * memory_file / (Speed_read_of_recording * 0.125)) / 60);
            int free = Get_memory_free();
            double result = (amount_files * memory_file / 1024) / free;
            int temp = Convert.ToInt32(result);
            if (temp < result)
            {
                return temp + 1;
            }
            return temp;
        }
        public int Get_time()
        {
            return time;
        }

        public override void Get_info()
        {
            Console.WriteLine($"Модель: {Model_name}\nТип: {Type}\nСкорость чтения/записи: {Speed_read_of_recording} Мбит\\с\nОбъём памяти: {Get_memory_size()} GB\nСвободно: {Get_memory_free()}");
        }

        public override int Get_memory_free()
        {
            return Memory - notFreeMemory;
        }

        public override int Get_memory_size()
        {
            if (Type == "Односторонний")
            {
                Memory = 5;
            }
            else
            {
                Memory = 9;
            }
            return Memory;
        }
    }
    class Flash : Storage
    {
        private int Speed_USB_3_0 { get; set; }
        private int Memory { get; set; }
        private int notFreeMemory = 0;
        int time;

        public Flash(int Speed_USB_3_0, int Memory, string Model_name) : base(Model_name)
        {
            this.Model_name = Model_name;
            this.Speed_USB_3_0 = Speed_USB_3_0;
            this.Memory = Memory;
        }
        public override double Copying_data(double amount_files, double memory_file)

        {
            time = Convert.ToInt32((amount_files * memory_file / (Speed_USB_3_0 * 125)) / 60);
            int free = Get_memory_free();
            double result = (amount_files * memory_file / 1024) / free;
            int temp = Convert.ToInt32(result);
            if (temp < result)
            {
                return temp + 1;
            }
            return temp;
        }
        public int Get_time()
        {
            return time;
        }

        public override void Get_info()
        {
            Console.WriteLine($"Модель: {Model_name}\nСкорость USB 3.0: {Speed_USB_3_0} Гбит\\с \nОбъём памяти: {Memory} GB\nСвободно: {Get_memory_free()}");
        }

        public override int Get_memory_free()
        {
            return Memory - notFreeMemory;
        }

        public override int Get_memory_size()
        {
            return Memory;
        }
    }

    class HDD : Storage
    {
        private int Speed_USB_2_0 { get; set; }
        private int Value_of_directory { get; set; }
        private int Memory_of_directorys { get; set; }
        private int Memory;
        private int notFreeMemory = 0;
        int time;

        public HDD(int Speed_USB_2_0, int Value_of_directory, int Memory_of_directorys, string Model_name) : base(Model_name)
        {
            this.Speed_USB_2_0 = Speed_USB_2_0;
            this.Value_of_directory = Value_of_directory;
            this.Memory_of_directorys = Memory_of_directorys;
            this.Model_name = Model_name;
        }

        public override double Copying_data(double amount_files, double memory_file)
        {
            time = Convert.ToInt32((amount_files * memory_file / (Speed_USB_2_0 * 0.125)) / 60);
            int free = Get_memory_free();
            double result = (amount_files * memory_file / 1024) / free;
            int temp = Convert.ToInt32(result);
            if (temp < result)
            {
                return temp + 1;
            }
            return temp;
        }

        public int Get_time()
        {
            return time;
        }

        public override void Get_info()
        {
            Console.WriteLine($"Модель: {Model_name}\nКоличество разделов: {Value_of_directory}\nСкорость USB 2.0 {Speed_USB_2_0} Мбит\\с\nОбъём памяти раздела: {Memory_of_directorys} GB\nОбщий объём памяти: {Get_memory_size()}\nСвободно: {Get_memory_free()}");
        }

        public override int Get_memory_free()
        {
            return Memory - notFreeMemory;
        }

        public override int Get_memory_size()
        {
            return Memory = Value_of_directory * Memory_of_directorys;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flash flash = new Flash(5, 64, "Smartbuy");
            flash.Get_info();
            Console.WriteLine($"Для переноса этого объёма данных вам понадобиться {flash.Copying_data(780, 720)} Flash накопителей.\nВремя копирования: {flash.Get_time()} минут.\n");

            DVD dvd = new DVD(1, "Двусторонний", "Sony");
            dvd.Get_info();
            Console.WriteLine($"Для переноса этого объёма данных вам понадобиться {dvd.Copying_data(780, 720)} dvd дисков.\nВремя копирования: {dvd.Get_time()} минут.\n");

            HDD hdd = new HDD(480, 2, 120, "Western Digital");
            hdd.Get_info();
            Console.WriteLine($"Для переноса этого объёма данных вам понадобиться {hdd.Copying_data(780, 720)} hdd дисков.\nВремя копирования: {hdd.Get_time()} минут.\n");

            Console.ReadKey();
        }
    }
}
