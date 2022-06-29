namespace GlobalSharesRocketLib
{
    public class LandingArea
    {
        private int h;
        private int v;

        private int platformH;
        private int platformV;

        private int platformX;
        private int platformY;

        // This field it's ti handler only the last check of each rocket
        private Dictionary<int, RokectRequest> rocketRequests;


        private bool[,] platform;

        public LandingArea()
        {
            h = 100;
            v = 100;

            rocketRequests = new Dictionary<int, RokectRequest>();

            ChangePlatformSize(10, 10);
            ChangePlatformPosition(5, 5);
        }

        public void ChangePlatformPosition(int x, int y)
        {
            platformX = x;
            platformY = y;
        }

        public void ChangePlatformSize(int h, int v)
        {
            platformH = h;
            platformV = v;

            platform = new bool[platformH, platformV];
        }

        public string RocketRequest(int rocketId, int x, int y)
        {
            if (rocketRequests.ContainsKey(rocketId))
                UpdateAreaRocket(rocketRequests[rocketId], false);

            var result = "ok for landing";
            var add = true;
            var limitX = platformX + platformH - 1;
            var limitY = platformY + platformV - 1;

            if (platformX > x || x > limitX || platformY > y || y > limitY)
            {
                result = "out of platform";
                add = false;
            }
            else if (platform[x - platformX, y - platformY])
            {
                result = "clash";
                add = false;
            }

            if (add)
            {
                var newRocketRequest = new RokectRequest { Id = rocketId, X = x, Y = y };

                rocketRequests[rocketId] = newRocketRequest;

                UpdateAreaRocket(newRocketRequest, true);
            }
            else if (rocketRequests.ContainsKey(rocketId))
            {
                UpdateAreaRocket(rocketRequests[rocketId], true);
            }

            return result;
        }

        private void UpdateAreaRocket(RokectRequest rokectRequest, bool areaSet)
        {
            int x = rokectRequest.X - platformX;
            int y = rokectRequest.Y - platformY;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < platformH && j >= 0 && j < platformV)
                        platform[i, j] = areaSet;
                }
            }
        }
    }
}