package fploy.model;

public class Organization {
    private int orgId;
    private String orgName;
    private String orgDescription;

    public Organization() {
    }

    public Organization(int orgId, String orgName, String orgDescription) {
        this.orgId = orgId;
        this.orgName = orgName;
        this.orgDescription = orgDescription;
    }

    public int getOrgId() {
        return orgId;
    }

    public void setOrgId(int orgId) {
        this.orgId = orgId;
    }

    public String getOrgName() {
        return orgName;
    }

    public void setOrgName(String orgName) {
        this.orgName = orgName;
    }

    public String getOrgDescription() {
        return orgDescription;
    }

    public void setOrgDescription(String orgDescription) {
        this.orgDescription = orgDescription;
    }

    @Override
    public String toString() {
        return orgName;
    }
}
